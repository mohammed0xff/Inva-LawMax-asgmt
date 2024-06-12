import { Hearing } from "./hearing.model";

export interface Case {
  id: string;
  number: string;
  year: string;
  litigationDegree: string;
  finalVerdict: string;
  lawyerId: string; 
  hearings: Hearing[]; 
}
