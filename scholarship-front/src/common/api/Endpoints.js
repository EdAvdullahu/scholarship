const BASE_URL = "https://localhost:7203/api";
const useBasePath = (path) => `${BASE_URL}/${path}`;
export const API_ENDPOINTS = {
 USER: {
  NULL: () => useBasePath("User"),
  USER_LOGIN: () => useBasePath("User/login"),
  USER_SIGNIN: () => useBasePath("User/register"),
 },
 UNIVERSITY: {
  NULL: () => useBasePath("University"),
  UNIVERSITY_FACULTY: () => useBasePath("University/faculty"),
  UNIVERSITY_FACULTY_ID: (id) => useBasePath("University/faculty/" + id),
 },
};
