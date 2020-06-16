export enum PersonType {
    None = 0,
    Employee = 1,
    Dependent = 2
}

export interface Person {
    name: string;
    type: PersonType;
    deduction: number;
}