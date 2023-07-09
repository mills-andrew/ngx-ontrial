import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthSignUpComponent } from './sign-up.component';

const routes: Routes = [
	{ path: '', component: AuthSignUpComponent }
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class SignUpRoutingModule { }
