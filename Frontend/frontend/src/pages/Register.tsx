import { useState } from "react";
import { registerUser } from "../services/userService";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const navigate = useNavigate();

  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const register = async () => {
    try {
      await registerUser({ name, email, password });
      alert("Konto skapat!");
      navigate("/login");
    } catch (e: any) {
      alert(e.message);
    }
  };

  return (
    <div>
      <h2>Skapa konto</h2>

      <input
        placeholder="Namn"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <input
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <input
        type="password"
        placeholder="Lösenord"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <button onClick={register}>Registrera</button>
    </div>
  );
}