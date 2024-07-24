using Microsoft.EntityFrameworkCore;
using QuoteRequestApp.Application.Services.Interfaces;
using QuoteRequestApp.Core.Models;
using QuoteRequestApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services
{
    public class DimensionService : IDimensionService
    {
        private readonly AppDbContext _context;

        public DimensionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dimension>> GetDimensionsAsync()
        {
            return await _context.Dimensions.ToListAsync();
        }

        public async Task<int> CalculatePalletCount(double unitLength, string unitType)
        {
            if (unitType == "IN")
            {
                unitLength = ConvertInchesToCm(unitLength);
            }


            var carton = await _context.Dimensions.FirstOrDefaultAsync(d => d.Type == "Carton");
            var box = await _context.Dimensions.FirstOrDefaultAsync(d => d.Type == "Box");
            var pallet = await _context.Dimensions.FirstOrDefaultAsync(d => d.Type == "Pallet");

            if (carton == null || box == null || pallet == null)
                throw new Exception("Required dimensions not found.");


            int boxCount = CalculateBoxCountFromCarton(carton, box, unitLength);

            int palletCount = CalculatePalletCountFromBox(boxCount, box, pallet, unitLength);

            return palletCount;
        }


        private int CalculateBoxCountFromCarton(Dimension carton, Dimension box, double unitLength)
        {
            if (unitLength <= 2)
                throw new ArgumentException("Unit length cannot be less than 2 cm.");

            if (carton.Width <= 0 || carton.Length <= 0 || carton.Height <= 0)
                throw new ArgumentException("Invalid carton dimensions.");
            if (box.Width <= 0 || box.Length <= 0 || box.Height <= 0)
                throw new ArgumentException("Invalid box dimensions.");

            double cartonArea = carton.Width * carton.Length * unitLength;

            double boxArea = box.Width * box.Length;
            int boxCount = (int)Math.Floor(cartonArea / boxArea);

            return boxCount;
        }

        private int CalculatePalletCountFromBox(int boxCount, Dimension box, Dimension pallet, double unitLength)
        {
            if (boxCount <= 0)
                throw new ArgumentException("Box count must be greater than zero.");
            if (pallet.Width <= 0 || pallet.Length <= 0 || pallet.Height <= 0)
                throw new ArgumentException("Invalid pallet dimensions.");

            // unitLength'i kullanarak gerçek palet genişliği, uzunluğu ve yüksekliğini belirleyin
            double palletArea = pallet.Width * pallet.Length * unitLength;

            // Kutu alanı hesaplanır ve birim kareye düşen palet sayısı belirlenir
            double boxArea = box.Width * box.Length;
            int palletCount = (int)Math.Floor(palletArea / boxArea);

            return boxCount * palletCount;
        }

        private double ConvertInchesToCm(double inches)
        {
            return inches * 2.54;
        }

    }
}
