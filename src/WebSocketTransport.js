// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { LogLevel } from "./ILogger";
import { TransferFormat } from "./ITransport";
import { Arg, getDataDetail } from "./Utils";
/** @private */
export class WebSocketTransport {
    constructor(accessTokenFactory, logger, logMessageContent) {
        this.logger = logger;
        this.accessTokenFactory = accessTokenFactory || (() => null);
        this.logMessageContent = logMessageContent;
    }
    connect(url, transferFormat) {
        return __awaiter(this, void 0, void 0, function* () {
            Arg.isRequired(url, "url");
            Arg.isRequired(transferFormat, "transferFormat");
            Arg.isIn(transferFormat, TransferFormat, "transferFormat");
            if (typeof (WebSocket) === "undefined") {
                throw new Error("'WebSocket' is not supported in your environment.");
            }
            this.logger.log(LogLevel.Trace, "(WebSockets transport) Connecting");
            const token = yield this.accessTokenFactory();
            if (token) {
                url += (url.indexOf("?") < 0 ? "?" : "&") + `access_token=${encodeURIComponent(token)}`;
            }
            return new Promise((resolve, reject) => {
                url = url.replace(/^http/, "ws");
                const webSocket = new WebSocket(url);
                if (transferFormat === TransferFormat.Binary) {
                    webSocket.binaryType = "arraybuffer";
                }
                // tslint:disable-next-line:variable-name
                webSocket.onopen = (_event) => {
                    this.logger.log(LogLevel.Information, `WebSocket connected to ${url}`);
                    this.webSocket = webSocket;
                    resolve();
                };
                webSocket.onerror = (event) => {
                    reject(event.error);
                };
                webSocket.onmessage = (message) => {
                    this.logger.log(LogLevel.Trace, `(WebSockets transport) data received. ${getDataDetail(message.data, this.logMessageContent)}.`);
                    if (this.onreceive) {
                        this.onreceive(message.data);
                    }
                };
                webSocket.onclose = (event) => {
                    // webSocket will be null if the transport did not start successfully
                    this.logger.log(LogLevel.Trace, "(WebSockets transport) socket closed.");
                    if (this.onclose) {
                        if (event.wasClean === false || event.code !== 1000) {
                            this.onclose(new Error(`Websocket closed with status code: ${event.code} (${event.reason})`));
                        }
                        else {
                            this.onclose();
                        }
                    }
                };
            });
        });
    }
    send(data) {
        if (this.webSocket && this.webSocket.readyState === WebSocket.OPEN) {
            this.logger.log(LogLevel.Trace, `(WebSockets transport) sending data. ${getDataDetail(data, this.logMessageContent)}.`);
            this.webSocket.send(data);
            return Promise.resolve();
        }
        return Promise.reject("WebSocket is not in the OPEN state");
    }
    stop() {
        if (this.webSocket) {
            this.webSocket.close();
            this.webSocket = null;
        }
        return Promise.resolve();
    }
}
//# sourceMappingURL=WebSocketTransport.js.map