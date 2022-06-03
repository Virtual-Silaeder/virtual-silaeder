from flask_socketio import SocketIO
from flask import Flask, send_from_directory, render_template

from ip import ip_address, port


async_mode = None
app = Flask(__name__, static_url_path='')
socketio = SocketIO(app, async_mode=async_mode)


# Main page
@app.route('/')
def root():
    return render_template('index.html')


# Get files from server (e.g. libs)
@app.route('/js/<path:path>')
def send_js(path):
    return send_from_directory('js', path)


if __name__ == "__main__":
    print(f'Listening on http://{ip_address}:{port}')
    socketio.run(app, host=ip_address, port=port)
