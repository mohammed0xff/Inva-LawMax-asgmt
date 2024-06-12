import { Case } from "./case.model";

export interface Lawyer {
  id: string; 
  name: string;
  position: string;
  mobile: string;
  address: string;
  cases: Case[];
}
