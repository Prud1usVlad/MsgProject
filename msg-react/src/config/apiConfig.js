export const apiConfig = {
    url: "http://192.168.31.28:5157/api/",
    defaultHeaders: { headers: { 'Authorization': `Bearer ${localStorage.getItem("token")}`}},
    currencyRateUrl: "https://api.apilayer.com/fixer/latest?base=USD&symbols=UAH",
    currencyRateKey: "iZhg8X8VDLPOzy1d8kCsliBxN68YEZoA",
}