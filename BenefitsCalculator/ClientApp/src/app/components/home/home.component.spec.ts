import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { HomeComponent } from './home.component';
import { MaterialModule } from 'src/app/material.module';
import { BenefitsService } from 'src/app/services/benefits.service';
import { MockBenefitsService } from 'src/app/services/stubs/benefits.mock';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

describe('HomeComponent', () => {
    let component: HomeComponent;
    let fixture: ComponentFixture<HomeComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [HomeComponent],
            imports: [
                MaterialModule,
                NoopAnimationsModule,
                HttpClientTestingModule
            ],
            providers: [
                { provide: BenefitsService, useClass: MockBenefitsService }
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(HomeComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
