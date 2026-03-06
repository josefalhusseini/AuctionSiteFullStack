import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAuctions, searchAuctions } from "../services/auctionService";
import type { Auction } from "../types/types";

export default function Auctions() {
  const [auctions, setAuctions] = useState<Auction[]>([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    load();
  }, []);

  const load = async () => {
    const data = await getAuctions();
    setAuctions(data);
  };

  const handleSearch = async () => {
    const data = await searchAuctions(search);
    setAuctions(data);
  };

  return (
    <div>
      <h1>Auktioner</h1>

      <input
        placeholder="Sök titel..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
      />
      <button onClick={handleSearch}>Sök</button>

      {auctions.map((a) => (
        <div key={a.id} className="card">
          <Link to={`/auctions/${a.id}`}>
            <h3>{a.title}</h3>
          </Link>
          <p>{a.description}</p>
          <p>Pris: {a.price}</p>
          <p>Start: {new Date(a.startDate).toLocaleString()}</p>
          <p>Slut: {new Date(a.endDate).toLocaleString()}</p>
        </div>
      ))}
    </div>
  );
}