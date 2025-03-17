import { Address } from "./Adress";

export type User = {
    firstName: string;
    lastName: string;
    email: string;
    address: Address;
}

export type { Address };

