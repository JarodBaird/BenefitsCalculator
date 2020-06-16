import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyComponent } from './family.component';
import { MaterialModule } from 'src/app/material.module';

describe('FamilyComponent', () => {
    let component: FamilyComponent;
    let fixture: ComponentFixture<FamilyComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [FamilyComponent],
            imports: [MaterialModule]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(FamilyComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});