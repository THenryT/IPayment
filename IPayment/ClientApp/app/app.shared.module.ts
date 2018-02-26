import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { SearchPaymentsComponent } from './components/searchPayments/searchPayments.component';

import { PaymentService } from './services/paymentService';
import { GrowlModule } from 'primeng/growl';
import { MessageService } from 'primeng/components/common/messageservice';
import { DataTableModule } from 'primeng/datatable';
import { DateFormateBuildPipe } from './utilities/pipes/date-format-pipe';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        SearchPaymentsComponent,
        DateFormateBuildPipe
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        GrowlModule,
        DataTableModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'paymentSearch', component: SearchPaymentsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [PaymentService, MessageService]
})
export class AppModuleShared {
}
