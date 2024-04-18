import axios from "axios";

const apiPort = "7184";
const ip = "";
const urlApi = `https://localhost:${apiPort}/api`;

export const audioToTextSource = "";
export const textToAudioSource = "/text-to-audio";

const api = axios.create({
  baseURL: urlApi,
});

export default api;
