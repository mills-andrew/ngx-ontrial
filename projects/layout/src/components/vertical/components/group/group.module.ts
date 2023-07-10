import { NgModule } from '@angular/core';
import { VerticalNavigationGroupItemComponent } from './group.component';
import { VerticalNavigationBasicItemModule } from '../basic/basic.module';
import { VerticalNavigationCollapsableItemModule } from '../collapsable/collapsable.module';
import { VerticalNavigationDividerItemModule } from '../divider/divider.module';
import { VerticalNavigationSpacerItemModule } from '../spacer/spacer.module';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

@NgModule({
	declarations: [
		VerticalNavigationGroupItemComponent
	],
	imports: [
		CommonModule,
		MatIconModule,
		VerticalNavigationBasicItemModule,
		VerticalNavigationCollapsableItemModule,
		VerticalNavigationDividerItemModule,
		VerticalNavigationSpacerItemModule
	],
	exports: [
		VerticalNavigationGroupItemComponent,
	]
})
export class VerticalNavigationGroupItemModule {
}
