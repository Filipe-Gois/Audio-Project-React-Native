import axios from "axios";

const apiPort = "4056";
const ip = "192.168.15.61";
const urlApi = `http://${ip}:${apiPort}/api`;

export const falaParaTextoSource = "/SpeechToText";
export const textoParaFalaSource = "/TextToSpeech";

const api = axios.create({
  baseURL: urlApi,
});

export default api;
