import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function Navbar() {
  const { user, logout } = useAuth();

  return (
    <nav className="nav">
      <Link to="/">Hem</Link>

      {user && <Link to="/create">Skapa auktion</Link>}

      {!user && <Link to="/login">Logga in</Link>}
      {!user && <Link to="/register">Skapa konto</Link>}

      {user && (
        <>
          <span>Inloggad som: {user.email}</span>
          <button onClick={logout}>Logga ut</button>
        </>
      )}
    </nav>
  );
}