import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getAuctions } from "../services/auctionService";
import { getBids, placeBid } from "../services/bidService";
import { useAuth } from "../context/AuthContext";
import type { Auction, Bid } from "../types/types";

export default function AuctionDetails() {
  const { id } = useParams();
  const { user } = useAuth();

  const [auction, setAuction] = useState<Auction | null>(null);
  const [bids, setBids] = useState<Bid[]>([]);
  const [amount, setAmount] = useState(0);

  useEffect(() => {
    loadAuction();
    loadBids();
  }, [id]);

  const loadAuction = async () => {
    const data = await getAuctions();
    const found = data.find(a => a.id === Number(id));
    setAuction(found || null);
  };

  const loadBids = async () => {
    const data = await getBids(Number(id));
    setBids(data);
  };

  const handleBid = async () => {
    if (!user) return alert("Logga in");

    try {
      await placeBid({
        auctionId: Number(id),
        userId: user.id,
        amount
      });

      alert("Bud lagt!");
      setAmount(0);
      loadBids();
    } catch (e: any) {
      alert(e.message);
    }
  };

  if (!auction) return <p>Laddar...</p>;

  return (
    <div>
      <h2>{auction.title}</h2>
      <p>{auction.description}</p>
      <p>Start: {new Date(auction.startDate).toLocaleString()}</p>
      <p>Slut: {new Date(auction.endDate).toLocaleString()}</p>
      <p>Startpris: {auction.price} kr</p>

      <h3>Bud</h3>

      {bids.length === 0 && <p>Inga bud än</p>}

      {bids.map(b => (
        <div key={b.id}>
          <p>{b.amount} kr</p>
        </div>
      ))}

      <hr />

      {!user && <p>Logga in för att lägga bud</p>}

      {user && user.id === auction.userId && (
        <p>Du kan inte lägga bud på din egen auktion</p>
      )}

      {user && user.id !== auction.userId && (
        <>
          <input
            type="number"
            value={amount}
            onChange={e => setAmount(Number(e.target.value))}
          />
          <button onClick={handleBid}>Lägg bud</button>
        </>
      )}
    </div>
  );
}