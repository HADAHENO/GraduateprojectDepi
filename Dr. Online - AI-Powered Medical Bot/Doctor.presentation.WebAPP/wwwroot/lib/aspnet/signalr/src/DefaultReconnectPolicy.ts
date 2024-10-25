// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

import { IReconnectPolicy } from "./IReconnectPolicy";

// 0, 2, 10, 30 second delays before reconnect attempts.
const DEFAULT_RETRY_DELAYS_IN_MILLISECONDS = [0, 2000, 10000, 30000, null];

/** @private */
export class DefaultReconnectPolicy implements IReconnectPolicy {
    private readonly retryDelays: Array<number | null>;

    constructor(retryDelays?: number[]) {
        this.retryDelays = retryDelays !== undefined ? [...retryDelays, null] : DEFAULT_RETRY_DELAYS_IN_MILLISECONDS;
    }

    public nextRetryDelayInMilliseconds(previousRetryCount: number): number | null {
        return this.retryDelays[previousRetryCount];
    }
}
