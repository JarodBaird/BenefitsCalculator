import { Component } from '@angular/core';
import { Family } from "src/app/models/family.model";
import { BenefitsService } from "src/app/services/benefits.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  families: Family[];
  familyName: string;
  grandTotal: number;

  constructor(private _benefitsService: BenefitsService) {
    this.families = [];
    this.familyName = '';
    this.grandTotal = 0;
  }

  addFamily() {
    if (this.familyName !== '') {
      this.families.push({
        name: this.familyName,
        members: [],
        totalDeduction: 0
      });

      this.familyName = '';
    }
  }

  recalculate() {
    this._benefitsService.calculate(this.families).subscribe((res) => {
      this.families = res;
      this.grandTotal = this.families
        .map(f => f.members.map(m => m.deduction).reduce((a, b) => a + b))
        .reduce((a, b) => a + b);
    });
  }
}
