import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthUnlockSessionComponent } from './unlock-session.component';

const routes: Routes = [
	{ path: '', component: AuthUnlockSessionComponent }
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class UnlockSessionRoutingModule { }
