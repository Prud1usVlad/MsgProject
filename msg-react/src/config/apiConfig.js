export const apiConfig = {
    url: "http://192.168.31.28:5157/api/",
    defaultHeaders: { headers: { 'Authorization': `Bearer ${localStorage.getItem("token")}`}}
}