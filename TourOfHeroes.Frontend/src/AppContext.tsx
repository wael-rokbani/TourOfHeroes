import { createContext } from "react";
import { Hero } from "./generated";

export const AppContext = createContext<Hero[]>([]);
