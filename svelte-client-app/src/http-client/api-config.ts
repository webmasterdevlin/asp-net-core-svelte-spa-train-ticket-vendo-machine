import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7168/api",
});

export const EndPoints = {
  v1Stations: "/v1/Stations",
};
