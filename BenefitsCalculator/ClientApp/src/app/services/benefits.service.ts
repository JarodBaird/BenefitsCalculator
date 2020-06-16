import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Family } from '../models/family.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class BenefitsService {

    constructor(private _http: HttpClient) {}

    calculate(families: Family[]): Observable<Family[]> {
        return this._http.post<Family[]>('benefits/calculate', families);
    }
}