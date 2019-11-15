class Logger {
  constructor(log) {
    this._log = log;
  }

  info(isServerConnected, message) {
    if (isServerConnected) {
      this._log.info(message);
    }
  }

  warn(isServerConnected, message) {
    if (isServerConnected) {
      this._log.warn(message);
    }
  }

  error(isServerConnected, message) {
    if (isServerConnected) {
      this._log.error(message);
    }
  }
}

export default Logger;
