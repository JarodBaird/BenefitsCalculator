import { BenefitsService } from "../benefits.service";
import { Family } from "src/app/models/family.model";
import { Observable, of } from "rxjs";

export class MockBenefitsService extends BenefitsService {
    constructor() {
        super(null);
    }

    calculate(families: Family[]): Observable<Family[]> {
        for (let family of families) {
            for (let member of family.members) {
                member.deduction = 100;
            }
        }
        return of(families);
    }
}