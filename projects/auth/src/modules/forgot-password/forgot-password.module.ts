import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthForgotPasswordComponent } from './forgot-password.component';

const routes: Routes = [
	{ path: '', component: AuthForgotPasswordComponent }
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class ForgotPasswordRoutingModule { }
