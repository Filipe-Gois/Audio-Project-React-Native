import axios from "axios";

const apiPort = "";
const ip = "";
const urlApi = `http://${ip}:${apiPort}/api`;

const api = axios.create({
  baseURL: urlApi,
});

export default api;
