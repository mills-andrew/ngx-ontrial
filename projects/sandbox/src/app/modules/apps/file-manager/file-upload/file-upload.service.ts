import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class FileUploadService {

	constructor(private http: HttpClient) { }

	uploadFile(file: File): Observable<IUploadProgress> {
		const formData = new FormData();
		formData.append('file', file);

		// Replace with your upload URL
		const url = 'https://your-api.com/upload';

		return this.http.post<IUploadProgress>(url, formData, {
			reportProgress: true,
			observe: 'events',
		})
			.pipe(
				map((event) => {
					if (event.type === HttpEventType.UploadProgress) {
						const total = Math.round(event.loaded / event.total! * 100);
						return { total };
					} else if (event.type === HttpEventType.Response) {
						return { total: 100 };
					}
					throw new Error("Invalid event type");
				})
			);
	}
}

interface IUploadProgress {
	total: number; // Percentage progress from 0 to 100
}
