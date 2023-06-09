export const apiConfig = {
    url: "https://msg-api-uj0c.onrender.com/api/",
    defaultHeaders: { headers: { 'Authorization': `Bearer ${localStorage.getItem("token")}`}},
    currencyRateUrl: "https://api.apilayer.com/fixer/latest?base=USD&symbols=UAH",
    currencyRateKey: "iZhg8X8VDLPOzy1d8kCsliBxN68YEZoA",
}