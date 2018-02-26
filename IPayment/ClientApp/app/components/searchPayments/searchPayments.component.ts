import { Component, Input } from '@angular/core';
import { PaymentService } from '../../services/paymentService';
import { Payment } from '../../models/payment';
import { MessageService } from 'primeng/components/common/messageservice';
import { Message } from 'primeng/components/common/api';

@Component({
    selector: 'searchPayments',
    templateUrl: './searchPayments.component.html'
})
export class SearchPaymentsComponent {
    payments: Payment[];
    accountNum: string;
    msgs: Message[] = [];
    local: string = 'en-AU';
    type: string = 'dateOnly';
    constructor(private paymentService: PaymentService, private messageService: MessageService) {
        this.payments = [];
    }

    SearchPayments() {
        console.log('search');
        if (this.accountNum) {
            this.paymentService.getPaymentsByAccoutNum(this.accountNum).then(result => {
                console.debug(result);
                this.payments = result;
                this.msgs = [];
                this.msgs.push({ severity: 'success', summary: 'Success Message', detail: 'payment maked' });
            }).catch(err => {
                this.msgs = [];
                this.msgs.push({ severity: 'error', summary: 'Error Message', detail: err.message });
            })
        }
    }
}
