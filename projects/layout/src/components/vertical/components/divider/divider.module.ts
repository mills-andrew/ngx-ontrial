import { NgModule } from '@angular/core';
import { VerticalNavigationDividerItemComponent } from './divider.component';
import { CommonModule } from '@angular/common';

@NgModule({
	declarations: [
		VerticalNavigationDividerItemComponent
	],
	imports: [
		CommonModule
	],
	exports: [
		VerticalNavigationDividerItemComponent,
	]
})
export class VerticalNavigationDividerItemModule {
}
