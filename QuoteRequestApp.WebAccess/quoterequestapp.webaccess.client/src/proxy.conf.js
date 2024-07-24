const PROXY_CONFIG = [
  {
    "/api": {
      "target": "https://localhost:44389",
      "secure": false
    }
  }
]

module.exports = PROXY_CONFIG;
