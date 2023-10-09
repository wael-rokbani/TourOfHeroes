/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Hero } from '../models/Hero';
import type { HeroType } from '../models/HeroType';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class HeroesService {

    /**
     * @returns Hero Success
     * @throws ApiError
     */
    public static getApiV1Heroes(): CancelablePromise<Array<Hero>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/Heroes',
        });
    }

    /**
     * @param requestBody 
     * @returns Hero Created
     * @throws ApiError
     */
    public static postApiV1Heroes(
requestBody?: Hero,
): CancelablePromise<Hero> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/v1/Heroes',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param id 
     * @returns Hero Success
     * @throws ApiError
     */
    public static getApiV1Heroes1(
id: number,
): CancelablePromise<Hero> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/Heroes/{id}',
            path: {
                'id': id,
            },
        });
    }

    /**
     * @param id 
     * @param requestBody 
     * @returns Hero Success
     * @throws ApiError
     */
    public static putApiV1Heroes(
id: number,
requestBody?: Hero,
): CancelablePromise<Hero> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/v1/Heroes/{id}',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param id 
     * @returns number Success
     * @throws ApiError
     */
    public static deleteApiV1Heroes(
id: number,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/v1/Heroes/{id}',
            path: {
                'id': id,
            },
        });
    }

    /**
     * @returns HeroType Success
     * @throws ApiError
     */
    public static getApiV1HeroesTypes(): CancelablePromise<Array<HeroType>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/v1/Heroes/Types',
        });
    }

}
