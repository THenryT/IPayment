import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Payment } from '../models/payment';

@Injectable()
export class PaymentService {

    constructor(private http: Http) {

    }

    makePayment(request: Payment): Promise<Payment> {
        const url = `api/payment`;
        return this.http.post(url, request).toPromise().then(response => {
            return response.json();
        })
            .catch(this.handleError)
    }


    getPaymentsByAccoutNum(accountNum: string): Promise<Payment[]> {
        console.log("triggle get payments");
        const url = `api/payment?accountNum=${accountNum}`;
        return this.http.get(url).toPromise().then(response => {
            console.log(response.json());
            return response.json();
        }).catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        return Promise.reject(error.json());
    }
}