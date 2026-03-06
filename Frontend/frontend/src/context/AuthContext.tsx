import { createContext, useContext, useState, useEffect } from "react";
import type { ReactNode } from "react";
import { loginUser } from "../services/userService";
import type { User } from "../types/types";

type AuthContextType = {
  user: User | null;
  login: (name: string, password: string) => Promise<boolean>;
  logout: () => void;
};

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    const stored = localStorage.getItem("user");
    if (stored) setUser(JSON.parse(stored));
  }, []);

const login = async (email: string, password: string) => {
  try {
    const userId = await loginUser({ email, password });
    const u = { id: userId, name: email, email };
    setUser(u);
    localStorage.setItem("user", JSON.stringify(u));
    return true;
  } catch {
    return false;
  }
};

  const logout = () => {
    setUser(null);
    localStorage.removeItem("user");
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext)!;
}