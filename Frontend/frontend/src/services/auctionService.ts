import { apiGet, apiPost } from "./api";
import type { Auction } from "../types/types";

export function getAuctions() {
  return apiGet<Auction[]>("/Auctions");
}

export function searchAuctions(title: string) {
  return apiGet<Auction[]>(`/Auctions/search?title=${encodeURIComponent(title)}`);
}

export function createAuction(data: {
  title: string;
  description: string;
  price: number;
  endDate: string;
  userId: number;
}) {
  return apiPost<Auction>("/Auctions", data);
}