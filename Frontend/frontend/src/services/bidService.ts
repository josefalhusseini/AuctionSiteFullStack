import { apiGet, apiPost } from "./api";
import type { Bid } from "../types/types";

export function getBids(auctionId: number) {
  return apiGet<Bid[]>(`/Bids/${auctionId}`);
}

export function placeBid(data: { auctionId: number; userId: number; amount: number }) {
  return apiPost<Bid>("/Bids", data);
}