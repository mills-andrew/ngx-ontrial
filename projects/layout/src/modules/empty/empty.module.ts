import { NgModule } from '@angular/core';
import { EmptyLayoutComponent } from './empty.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { RouterModule } from '@angular/router';

@NgModule({
	declarations: [
		EmptyLayoutComponent
	],
	imports: [
		RouterModule,
		LoadingBarComponent
	],
	exports: [
		EmptyLayoutComponent,
	]
})
export class EmptyLayoutModule {
}
