import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class AppInitializeConfigService {
	public version?: string;
	public apiEndpoint?: string;

	constructor(private http: HttpClient) { }

	load(): Promise<any> {
		const promise = this.http.get('/app.config.json')
			.toPromise()
			.then(data => {
				Object.assign(this, data);
				return data;
			});

		return promise;
	}
}