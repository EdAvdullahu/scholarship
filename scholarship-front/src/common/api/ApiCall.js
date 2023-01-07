import axios from "axios";
const BASE_URL = "https://28e9528d-f483-4bca-84a1-e0d10bcf886d.mock.pstmn.io/";
export const callApi = (endpoint) => {
 let url = BASE_URL + "/" + endpoint;
 console.log(url);
 return {
  fetchAll: () => axios.get(BASE_URL),
 };
};
