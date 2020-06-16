import { Person } from './person.model';

export interface Family {
    name: string;
    members: Person[];
    totalDeduction: number;
}