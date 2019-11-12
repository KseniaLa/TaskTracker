class Logger {
  constructor(log) {
    this._log = log;
  }

  info(isServerConnected, message) {
    if (isServerConnected) {
      this._log.info(message);
    }
  }
}

export default Logger;
