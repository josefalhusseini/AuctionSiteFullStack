import { Routes, Route, Navigate } from "react-router-dom";
import Auctions from "../pages/Auctions";
import AuctionDetails from "../pages/AuctionDetails";
import CreateAuction from "../pages/CreateAuction";
import Login from "../pages/Login";
import Register from "../pages/Register";

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/auctions" replace />} />
      <Route path="/auctions" element={<Auctions />} />
      <Route path="/auctions/:id" element={<AuctionDetails />} />
      <Route path="/create" element={<CreateAuction />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
    </Routes>
  );
}