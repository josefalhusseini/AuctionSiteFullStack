
export type User = {
  id: number;
  name: string;
  email: string;
};

export type Auction = {
  id: number;
  title: string;
  description: string;
  price: number;
  startDate: string;
  endDate: string;
  userId: number;
};

export type Bid = {
  id: number;
  amount: number;
  date: string;
  userId: number;
  auctionId: number;
};