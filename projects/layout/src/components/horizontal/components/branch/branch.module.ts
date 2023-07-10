import { NgModule } from '@angular/core';
import { HorizontalNavigationBranchItemComponent } from './branch.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CommonModule } from '@angular/common';
import { HorizontalNavigationDividerItemModule } from '../divider/divider.module';
import { HorizontalNavigationBasicItemModule } from '../basic/basic.module';

@NgModule({
	declarations: [
		HorizontalNavigationBranchItemComponent
	],
	imports: [
		CommonModule,
		MatIconModule,
		MatMenuModule,
		MatTooltipModule,
		HorizontalNavigationDividerItemModule,
		HorizontalNavigationBasicItemModule
	],
	exports: [
		HorizontalNavigationBranchItemComponent,
	]
})
export class HorizontalNavigationBranchItemModuler {
}
