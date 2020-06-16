import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Family } from 'src/app/models/family.model';
import { Person, PersonType } from 'src/app/models/person.model';

@Component({
    selector: 'app-family',
    templateUrl: './family.component.html',
    styleUrls: ['./family.component.scss']
})
export class FamilyComponent implements OnInit {
    @Input()
    family: Family;

    @Output()
    change: EventEmitter<Family>;

    personTypes = Object.keys(PersonType).filter(Number).map(f => parseInt(f));

    constructor() {
        this.change = new EventEmitter();
    }

    ngOnInit() {
        console.log(this.personTypes);
    }

    addFamilyMember() {
        this.family.members.push({
            name: '',
            type: PersonType.Employee,
            deduction: 0
        } as Person);
    }

    onChange() {
        this.change.emit();
    }
}