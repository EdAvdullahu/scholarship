import axios from "axios";
import { getCookie } from "../services/utilities.service";

const token = getCookie("token");

export default {
 get(endpoint) {
  console.log("endpoint", token);
  return axios.get(endpoint, { headers: { Authorization: `bearer ${token}` } });
 },
 post(endpoint, params) {
  return axios.post(endpoint, params, {
   headers: { Authorization: `bearer ${token}` },
  });
 },
 put(endpoint, params) {
  return axios.put(endpoint, params, {
   headers: { Authorization: `bearer ${token}` },
  });
 },
 noAuth(endpoint, params) {
  console.log("endpoint", endpoint);
  return axios.post(endpoint, params);
 },
};
