import { useState } from "react";
import { createAuction } from "../services/auctionService";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CreateAuction() {
  const { user } = useAuth();
  const navigate = useNavigate();

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState(0);
  const [endDate, setEndDate] = useState("");

  const handleSubmit = async () => {
    if (!user) return alert("Logga in");
    if (!endDate) return alert("Välj slutdatum");

    await createAuction({
      title,
      description,
      price,
      endDate: new Date(endDate).toISOString(),
      userId: user.id
    });

    alert("Auktion skapad!");
    navigate("/auctions");
  };

  return (
    <div>
      <h2>Skapa auktion</h2>

      <input placeholder="Titel" value={title} onChange={e => setTitle(e.target.value)} />
      <input placeholder="Beskrivning" value={description} onChange={e => setDescription(e.target.value)} />
      <input type="number" placeholder="Pris" value={price} onChange={e => setPrice(Number(e.target.value))} />

      <label>Slutdatum:</label>
      <input type="datetime-local" value={endDate} onChange={e => setEndDate(e.target.value)} />

      <button onClick={handleSubmit}>Skapa</button>
    </div>
  );
}