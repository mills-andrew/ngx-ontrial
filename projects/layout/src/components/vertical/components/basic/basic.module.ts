import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VerticalNavigationBasicItemComponent } from './basic.component';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
	declarations: [
		VerticalNavigationBasicItemComponent
	],
	imports: [
		CommonModule,
		MatIconModule,
		MatTooltipModule
	],
	exports: [
		VerticalNavigationBasicItemComponent,
	]
})
export class VerticalNavigationBasicItemModule {
}
