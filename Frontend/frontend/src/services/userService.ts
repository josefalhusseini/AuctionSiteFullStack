import { apiPost } from "./api";

export function loginUser(data: { email: string; password: string }) {
  return apiPost<number>("/Users/login", data);
}

export function registerUser(data: {
  name: string;
  email: string;
  password: string;
}) {
  return apiPost("/Users/register", data);
}