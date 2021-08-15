module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: [
    "plugin:vue/recommended",
    "eslint:recommended",
    "@vue/typescript/recommended",
    "@vue/prettier",
    "@vue/prettier/@typescript-eslint",
    "plugin:@typescript-eslint/eslint-recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:@typescript-eslint/recommended-requiring-type-checking",
  ],
  parser: "vue-eslint-parser",
  parserOptions: {
    ecmaVersion: 2020,
    project: `./tsconfig.json`,
    parser: "@typescript-eslint/parser"
  },
  rules: {
    "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
    '@typescript-eslint/no-var-requires': 0,
    '@typescript-eslint/no-explicit-any': 0,
    '@typescript-eslint/no-unsafe-member-access': 0,
    '@typescript-eslint/no-unsafe-assignment': 0,
    'quotes': ['error', 'single'],
    'object-curly-spacing': ['error', 'always'],
    'space-before-function-paren': ['error', 'always'],
    'new-cap': ['error', {
      'capIsNew': false
    }],
    'indent': ['error', 2],
    'max-len': ['warn', {
      'code': 80,
      'tabWidth': 2,
      'ignoreUrls': true,
      'ignoreComments': true,
      'ignoreTrailingComments': true,
      'ignoreStrings': true,
      'ignoreTemplateLiterals': true
    }],
  },
  overrides: [{
    files: [
      "**/__tests__/*.{j,t}s?(x)",
      "**/tests/unit/**/*.spec.{j,t}s?(x)",
    ],
    env: {
      jest: true,
    },
  }, ],
};