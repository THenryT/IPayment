import { Component, Input } from '@angular/core';
import { PaymentService } from '../../services/paymentService';
import { Payment } from '../../models/payment';
import { MessageService } from 'primeng/components/common/messageservice';
import { Message } from 'primeng/components/common/api';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {

    payment: Payment;
    msgs: Message[] = [];
    constructor(private paymentService: PaymentService, private messageService: MessageService) {
        this.payment = new Payment();
    }

    MakePayment(form: any) {
        this.paymentService.makePayment(this.payment).then(result => {
            console.log(result);
            this.msgs = [];
            this.msgs.push({ severity: 'success', summary: 'Success Message', detail: 'payment maked' });
            form.reset();
        }).catch(err => {
            this.msgs = [];
            this.msgs.push({ severity: 'error', summary: 'Error Message', detail: err.message }); 
        });
    }
}
