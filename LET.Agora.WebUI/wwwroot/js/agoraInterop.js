// agoraInterop.js

window.agoraInterop = {
    closeWindow: function (applyFlow) {
        window.parent.postMessage({
            type: 'agora:pos:close-window',
            applyFlow
        }, { targetOrigin: '*' });
    },

    invokeApi: function (args) {
        return new Promise((resolve, reject) => {
            const requestId = new Date().getTime().toString() + (Math.random() * 1000).toString();
            const timeoutId = setTimeout(() => {
                failed('Request timed out');
            }, args.timeout || 60000);

            function cleanup() {
                window.removeEventListener('message', onMessage);
                clearTimeout(timeoutId);
            }

            function failed(errorMessage) {
                cleanup();
                reject(new Error(errorMessage));
            }

            function completed(response) {
                cleanup();
                resolve(response);
            }

            const onMessage = ({ data }) => {
                if (data.requestId !== requestId) return;
                data.error ? failed(data.error) : completed(data.response);
            };

            window.addEventListener('message', onMessage);

            window.parent.postMessage({
                type: 'agora:pos:invoke-api',
                endpoint: args.endpoint,
                apiToken: args.apiToken,
                requestId: requestId,
                body: args.body || ''
            }, { targetOrigin: '*' });
        });
    }
};